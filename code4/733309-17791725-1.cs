        private static string ReplaceHtmlTemplate(string price, string time, string paymentMethod)
        {
            string bodyFile;
            string template = System.IO.Directory.GetCurrentDirectory() + "\\" + htmlDocName;
            using (StreamReader reader = new StreamReader(template))
            {
                bodyFile = reader.ReadToEnd();
                bodyFile = bodyFile.Replace("<%Price%>", price);
                bodyFile = bodyFile.Replace("<%Time%>", time);
                bodyFile = bodyFile.Replace("<%PaymentMethod%>", paymentMethod);
            }
            return bodyFile;
        }
