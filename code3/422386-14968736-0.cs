        public void TestAutoCompleteLookup()
        {
            var path = "";
            using (var c = SequentialDataCache<AutoCompleteItem>.Initialize())
            {
                path = c.Path;
                //add 100.000 items 
                for (int i = 0; i < 100000; i++)
                {
                    c.Add(new AutoCompleteItem() { Text = string.Format("{0}Text", i) });
                }
                
                //query
                var pattern = "1";
                var items = c.Where(autoCompleteItem => autoCompleteItem.Text.StartsWith(pattern)).ToArray();
            }
            if (File.Exists(path))
                File.Delete(path);
        }
        [Serializable]
        private class AutoCompleteItem
        {
            public string Text { get; set; }
        }
