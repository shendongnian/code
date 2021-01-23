    private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
    {
        minhaSigla = Sigla.Text;
        var quoteGetterTask = Task.Factory.StartNew(() => GetQuoteAndUpdateText(minhaSigla));
        quoteGetterTask.ContinueWith(task => 
        {
            var theResultOfYourServiceCall = task.Result;
            //You'll need to use a dispatcher here to set the value of the text box (see below)
            tb1.Text = theResultOfYourServiceCall;     //"UIElement-TO-UPDATE";
        });
    }
