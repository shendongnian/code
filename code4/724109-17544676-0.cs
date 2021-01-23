        /// <summary>
        /// Used the XpsDocumentWriter to write a FixedDocument which get created and contains the UIElements as single pages
        /// </summary>
        /// <param name="xpsWriter">XpsDocumentWriter</param>
        /// <param name="uiElements">List of UIElement</param>
        private void PrintUIElements(XpsDocumentWriter xpsWriter, List<UIElement> uiElements)
        {
            var fixedDoc = new FixedDocument();
            foreach (UIElement element in uiElements)
            {
                var fixedPage = new FixedPage();
                var pageContent = new PageContent();
                // add the UIElement object the FixedPage
                fixedPage.Children.Add(element);
                // add the FixedPage object the PageContent
                pageContent.Child = fixedPage;
                
                // add the PageContent object the FixedDocument
                fixedDoc.Pages.Add(pageContent);
            }
            xpsWriter.Write(fixedDoc);
        }
