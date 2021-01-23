    foreach (HtmlNode link in bodyNode.SelectNodes("//div[@class='content-b']"))
    {
        if (link.InnerText.Contains("Name"))
        {
            //MessageBox.Show("Found");
            textBox1.Text += "Name : " + link.NextSibling.InnerText;
        }
    
        textBox1.Text += link.InnerText;
    }
