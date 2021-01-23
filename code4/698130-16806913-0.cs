        public void getQuantity()
        {
            List<string> consumbleNames = new List<string>();
            List<int> quantity = new List<int>();
            //Cells[5] refer to 6th column : Quantity issued: you can use column name too
            for (int i = 0; i < yourDataGridView.Rows.Count; i++)
            {
                consumbleNames.Add(yourDataGridView.Rows[i].Cells[0].Value.ToString());
                quantity.Add((int)Convert.ToInt32(yourDataGridView.Rows[i].Cells[5].Value.ToString()));
            }
            List<string> distinctNames = new List<string>(consumbleNames.Distinct());
            List<int> quantityRelated = new List<int>(distinctNames.Count);
            for (int i = 0; i < distinctNames.Count; i++)
            {
                quantityRelated.Add(new int());
                for (int j = 0; j < consumbleNames.Count; j++)
                {
                    if (consumbleNames[j].Equals(distinctNames[i]))
                    {
                        quantityRelated[i] += quantity[j];
                    }
                }
            }
            foreach (int t in quantityRelated)
            {
                /* quantity corresponds to the each distinct item */
            }
        }
