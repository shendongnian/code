    MyPage<MyData> myPage = new MyPage<MyData>();
    myPage.Content = new MyData();
    myPage.Content.Text = new Dictionary<string, string>();
    myPage.Content.Text["foo"] = "bar";
    myPage.Content.Text["fizz"] = "buzz";
    foreach (var item in myPage.Content.Text)
    {
       Console.WriteLine(item.Key + item.Value);
    }
