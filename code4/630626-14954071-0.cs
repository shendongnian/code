        Task<string>.Factory.StartNew(() =>
    {
         string text = GetArticleText();
         Application.Current.Dispatcher.BeginInvoke(new Action(()=>MyTextProperty = text));   
    });
