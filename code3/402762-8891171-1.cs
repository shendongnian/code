        for (int i = 0; i < dataGridView1.Rows.Count; i++)
        {
            if (dataGridView1.Rows[i].Cells["currency"].FormattedValue.ToString() == "USD")
            {
                string tempval = dataGridView1.Rows[i].Cells["commission"].ToString();
                myCommission += double.Parse(dataGridView1.Rows[i].Cells["commission"].FormattedValue.ToString()) * (double.Parse(dataGridView1.Rows[i].Cells["price"].FormattedValue.ToString()) * UStoGB);
            }
            else if (dataGridView1.Rows[i].Cells["currency"].FormattedValue.ToString() == "EURO")
            {
                myCommission += double.Parse(dataGridView1.Rows[i].Cells["commission"].FormattedValue.ToString()) * (double.Parse(dataGridView1.Rows[i].Cells["price"].FormattedValue.ToString()) * EUtoGB);
            }
            else
            {
                myCommission += double.Parse(dataGridView1.Rows[i].Cells["commission"].FormattedValue.ToString()) * (double.Parse(dataGridView1.Rows[i].Cells["price"].FormattedValue.ToString()));
            }
        }
