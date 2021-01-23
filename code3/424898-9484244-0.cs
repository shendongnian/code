            foreach (var item in items)
            {
                Literal literal = new Literal();
                literal.text = item.html; //Assuming the item contains the html.
                MyPlaceholder.Controls.Add(literal);
            }
