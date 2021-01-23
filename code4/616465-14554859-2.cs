            DataSet rateTableDBDataSet1 = new DataSet();
            //ds = whatever your data is comming from
            bool doesItHaveData = rateTableDBDataSet1.Tables["RateTable"].Rows.Count > 0;
            if (doesItHaveData)
            {
                object col1row1 = rateTableDBDataSet1.Tables["RateTable"].Rows[0][0];
                object col2row1 = rateTableDBDataSet1.Tables["RateTable"].Rows[0][1];
                object col1row2 = rateTableDBDataSet1.Tables["RateTable"].Rows[1][0];
            }
