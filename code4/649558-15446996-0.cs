    var nodes = bodyNode.SelectNodes("//div[@class='contet-b']").ToList();
    for( int i =0; i < nodes.Count; i++)
    {
        var link = nodes[i];
        if (link.InnerText.Contains("Name"))
        {
            textBox1.Text += "Name : ";
            if (i + 1 < nodes.Count)
            {
                // append the value of next matching `div` node
                textBox1.Text += nodes[i + 1].InnerText.Trim();
                i++; // skip this node
            }
        }
    }
