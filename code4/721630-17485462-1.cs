    using System;
    using System.Printing;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;
    using System.Windows.Markup;
    using System.Windows.Media;
    using System.Windows.Xps;
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
    
            List<UIElement> UC = new List<UIElement>();
    
            for (int i = 0; i < 3; i++)
            {
                var uc = new UserControl
                {
                    Background = Brushes.Red,
                    Content = new TextBlock
                    {
                        Text = "Box:" + i,
                        Margin = new Thickness(12),
                        Background = Brushes.Orange
                    }
                };
                UC.Add(uc);
            }
    
            var pDialog = new PrintDialog();
    
            if (pDialog.ShowDialog() == true)
            {
                var xpsDocWriter = PrintQueue.CreateXpsDocumentWriter(pDialog.PrintQueue);
                PrintUIElements(xpsDocWriter, UC);
            }
        }
    
        /// <summary>
        /// Used the XpsDocumentWriter to write a FixedDocumentSequence which contains the UIElements as single pages
        /// </summary>
        /// <param name="xpsWriter"></param>
        /// <param name="uiElements"></param>
        private void PrintUIElements(XpsDocumentWriter xpsWriter, List<UIElement> uiElements)
        {
            FixedDocumentSequence fixedDocSeq = new FixedDocumentSequence();
    
            foreach (UIElement element in uiElements)
            {
                (fixedDocSeq as IAddChild).AddChild(toDocumentReference(element));
    
            }
    
            // write the FixedDocumentSequence as an XPS Document
            xpsWriter.Write(fixedDocSeq);
        }
    
        /// <summary>
        /// encapsulater for a UIElement in an DocumentReference
        /// DocumentReference(FixedDocument(PageContent(FixedPage(UIElement))))
        /// to simplify the print of multiple pages
        /// </summary>
        /// <param name="uiElement">the UIElement which</param>
        /// <returns>creates a DocumentReference</returns>
        private DocumentReference toDocumentReference(UIElement uiElement)
        {
            if (uiElement == null)
                throw new NullReferenceException("the UIElement has to be not null");
    
            FixedPage fixedPage = new FixedPage();
            PageContent pageContent = new PageContent();
            FixedDocument fixedDoc = new FixedDocument();
            DocumentReference docRef = new DocumentReference();
    
            #region Step1
    
            // add the UIElement object the FixedPage
            fixedPage.Children.Add(uiElement);
    
            #endregion
    
            #region Step2
    
            // add the FixedPage to the PageContent collection
            pageContent.BeginInit();
            ((IAddChild)pageContent).AddChild(fixedPage);
            pageContent.EndInit();
    
            #endregion
    
            #region Step 3
    
            // add the PageContent to the FixedDocument collection
            ((IAddChild)fixedDoc).AddChild(pageContent);
    
            #endregion
    
            #region Step 4
    
            // add the FixedDocument to the document reference collection
            docRef.BeginInit();
            docRef.SetDocument(fixedDoc);
            docRef.EndInit();
    
            #endregion
    
            return docRef;
        }
    }
