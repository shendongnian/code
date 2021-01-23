    using System;
    using System.IO;
    using System.Linq;
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    using iTextSharp.text.pdf.collection;
    
    public class FolderWriter {
        private const string Folder = @"C:\Path\to\your\pdf\files";
        private const string File1 = @"Pdf File 1.pdf";
        private const string File2 = @"Pdf File 2.pdf";
        private readonly string file1Path = Path.Combine(Folder, File1);
        private readonly string file2Path = Path.Combine(Folder, File2);
        private readonly string[] keys = new[] {
            "Type",
            "File"
        };
    
        public void Write(Stream stream) {
            using (Document document = new Document()) {
                PdfWriter writer = PdfWriter.GetInstance(document, stream);
    
                document.Open();
                document.Add(new Paragraph("This document contains a collection of PDFs"));
    
                PdfIndirectReference parentFolderObjectReference = writer.PdfIndirectReference;
                PdfIndirectReference childFolder1ObjectReference = writer.PdfIndirectReference;
                PdfIndirectReference childFolder2ObjectReference = writer.PdfIndirectReference;
                    
                PdfDictionary parentFolderObject = GetFolderDictionary(0);
                parentFolderObject.Put(new PdfName("Child"), childFolder1ObjectReference);
                parentFolderObject.Put(PdfName.NAME, new PdfString());
    
                PdfDictionary childFolder1Object = GetFolderDictionary(1);
                childFolder1Object.Put(PdfName.NAME, new PdfString("Folder 1"));
                childFolder1Object.Put(PdfName.PARENT, parentFolderObjectReference);
                childFolder1Object.Put(PdfName.NEXT, childFolder2ObjectReference);
    
                PdfDictionary childFolder2Object = GetFolderDictionary(2);
                childFolder2Object.Put(PdfName.NAME, new PdfString("Folder 2"));
                childFolder2Object.Put(PdfName.PARENT, parentFolderObjectReference);
    
                PdfCollection collection = new PdfCollection(PdfCollection.DETAILS);
                PdfCollectionSchema schema = CollectionSchema();
                collection.Schema = schema;
                collection.Sort = new PdfCollectionSort(keys);
                collection.Put(new PdfName("Folders"), parentFolderObjectReference);
                writer.Collection = collection;
    
                PdfFileSpecification fs;
                PdfCollectionItem item;
    
                fs = PdfFileSpecification.FileEmbedded(writer, file1Path, File1, null);
                item = new PdfCollectionItem(schema);
                item.AddItem("Type", "pdf");
                fs.AddCollectionItem(item);
    			// the description is apparently used to place the 
    			// file in a particular folder.  The number between the < and >
    			// is used to put the file in the folder that has the matching id
                fs.AddDescription(GetDescription(1, File1), false);
                writer.AddFileAttachment(fs);
    
                fs = PdfFileSpecification.FileEmbedded(writer, file2Path, File2, null);
                item = new PdfCollectionItem(schema);
                item.AddItem("Type", "pdf");
                fs.AddCollectionItem(item);
                fs.AddDescription(GetDescription(2, File2), false);
                writer.AddFileAttachment(fs);
    
                writer.AddToBody(parentFolderObject, parentFolderObjectReference);
                writer.AddToBody(childFolder1Object, childFolder1ObjectReference);
                writer.AddToBody(childFolder2Object, childFolder2ObjectReference);
    
                document.Close();
            }
        }
    
        private static string GetDescription(int id, string fileName) {
            return string.Format("<{0}>{1}", id, fileName);
        }
    
        private static PdfDictionary GetFolderDictionary(int id) {
            PdfDictionary dic = new PdfDictionary(new PdfName("Folder"));
            dic.Put(PdfName.CREATIONDATE, new PdfDate(DateTime.Now));
            dic.Put(PdfName.MODDATE, new PdfDate(DateTime.Now));
            dic.Put(PdfName.ID, new PdfNumber(id));
            return dic;
        }
    
        private static PdfCollectionSchema CollectionSchema() {
            PdfCollectionSchema schema = new PdfCollectionSchema();
            PdfCollectionField type = new PdfCollectionField("File type", PdfCollectionField.TEXT);
            type.Order = 0;
            schema.AddField("Type", type);
            PdfCollectionField filename = new PdfCollectionField("File", PdfCollectionField.FILENAME);
            filename.Order = 1;
            schema.AddField("File", filename);
            return schema;
        }
    }
