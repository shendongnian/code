    public void DisplayQuestion(Question q)
    {
        txt_block_question.Text = qu.question;
        btn_Answer_A.Content = q.a;
        btn_Answer_B.Content = q.b;
        btn_Answer_C.Content = q.c;
     }
    public void DisplaySummary()
    {
        foreach (var q in qu)
        {
            DisplayQuestion(qu);
        }
        NavigationService.Navigate(new Uri("/summary_page.xaml", UriKind.Relative));
    }
