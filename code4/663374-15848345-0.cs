    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using iTextSharp.text.pdf;
    
    namespace ReplaceLinks
    {
        public class ReplacePdfLinks
        {
            Dictionary<string, PdfObject> _namedDestinations;
            PdfReader _reader;
    
            public string InputPdf { set; get; }
            public string OutputPdf { set; get; }
            public Func<Uri, string> UriToNamedDestination { set; get; }
    
            public void Start()
            {
                updatePdfLinks();
                saveChanges();
            }
    
            private PdfArray getAnnotationsOfCurrentPage(int pageNumber)
            {
                var pageDictionary = _reader.GetPageN(pageNumber);
                var annotations = pageDictionary.GetAsArray(PdfName.ANNOTS);
                return annotations;
            }
    
            private static bool hasAction(PdfDictionary annotationDictionary)
            {
                return annotationDictionary.Get(PdfName.SUBTYPE).Equals(PdfName.LINK);
            }
    
            private static bool isUriAction(PdfDictionary annotationAction)
            {
                return annotationAction.Get(PdfName.S).Equals(PdfName.URI);
            }
    
            private void replaceUriWithLocalDestination(PdfDictionary annotationAction)
            {
                var uri = annotationAction.Get(PdfName.URI) as PdfString;
                if (uri == null)
                    return;
    
                if (string.IsNullOrWhiteSpace(uri.ToString()))
                    return;
    
                var namedDestination = UriToNamedDestination(new Uri(uri.ToString()));
                if (string.IsNullOrWhiteSpace(namedDestination))
                    return;
    
                PdfObject entry;
                if (!_namedDestinations.TryGetValue(namedDestination, out entry))
                    return;
    
                annotationAction.Remove(PdfName.S);
                annotationAction.Remove(PdfName.URI);
    
                var newLocalDestination = new PdfArray();
                annotationAction.Put(PdfName.S, PdfName.GOTO);
                var xRef = ((PdfArray)entry).First(x => x is PdfIndirectReference);
                newLocalDestination.Add(xRef);
                newLocalDestination.Add(PdfName.FITH);
                annotationAction.Put(PdfName.D, newLocalDestination);
            }
    
            private void saveChanges()
            {
                using (var fileStream = new FileStream(OutputPdf, FileMode.Create, FileAccess.Write, FileShare.None))
                using (var stamper = new PdfStamper(_reader, fileStream))
                {
                    stamper.Close();
                }
            }
    
            private void updatePdfLinks()
            {
                _reader = new PdfReader(InputPdf);
                _namedDestinations = _reader.GetNamedDestinationFromStrings();
    
                var pageCount = _reader.NumberOfPages;
                for (var i = 1; i <= pageCount; i++)
                {
                    var annotations = getAnnotationsOfCurrentPage(i);
                    if (annotations == null || !annotations.Any())
                        continue;
    
                    foreach (var annotation in annotations.ArrayList)
                    {
                        var annotationDictionary = (PdfDictionary)PdfReader.GetPdfObject(annotation);
    
                        if (!hasAction(annotationDictionary))
                            continue;
    
                        var annotationAction = annotationDictionary.Get(PdfName.A) as PdfDictionary;
                        if (annotationAction == null)
                            continue;
    
                        if (!isUriAction(annotationAction))
                            continue;
    
                        replaceUriWithLocalDestination(annotationAction);
                    }
                }
            }
        }    
    }
