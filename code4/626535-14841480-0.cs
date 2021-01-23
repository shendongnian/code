    private void button1_Click(object sender, RoutedEventArgs e)
    {
        IList dictionaries = SpellCheck.GetCustomDictionaries(richTextBox1);
        // customwords2.lex is included as a resource file
        dictionaries.Add(new Uri(@"pack://application:,,,/WPFCustomDictionary;component/customwords2.lex"));
    }
