        string str = dataSet.Tables[0].Rows[0]["Ingredients"].ToString();
        string[] split = str.Split(',');
        // not needed IList<string> lblListItemIngredients  = new List<string>();
        foreach (string item in split)
        {
          literalIngredients.Text += string.Format("<li>{0}</li>",item);
        }
