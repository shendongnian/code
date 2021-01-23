        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var serviceUri = new Uri("https://api.datamarket.azure.com/Bing/MicrosoftTranslator/");
            var accountKey = "**********************"; // 
            var tcode = new Microsoft.TranslatorContainer(serviceUri);
            
            tcode.Credentials = new NetworkCredential(accountKey, accountKey);
            tcode.UseDefaultCredentials = false;
            var query = tcode.GetLanguagesForTranslation();
            query.BeginExecute(OnQueryComplete, query);
        }
        public void OnQueryComplete(IAsyncResult result)
        {
            var query = (DataServiceQuery<Microsoft.Language>)result.AsyncState;
            var enumerableLanguages = query.EndExecute(result);
            string langstring = "";
            foreach (Microsoft.Language lang in enumerableLanguages)
            {
                langstring += lang.Code + "\n";
            }
            MessageBox.Show(langstring);
        }
