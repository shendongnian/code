     foreach (string ticker in tickerList)
        {
            if (InputTickers.Text.Split(',').Contains(ticker))
                 {
                     tickerList.Add(InputTickers.Text);
                 }
        }
