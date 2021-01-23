            List<Books> a = new List<Books>();
            var kitap = doc.Descendants("Author");
            foreach (var item in kitap)
            {
                a.Add(new Books {AuthorName = item.Value, BookName = ""});
            }
            XDocument doc1 = XDocument.Load("XMLFile2.xml");
            List<Books> b = new List<Books>();
            var kitauthor = doc1.Descendants("Book").Where(i => i.Element("Author").Value == a[1].AuthorName).FirstOrDefault();
            
