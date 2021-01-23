    void checking_fields()
    {
        OleDbCommand cmd = new OleDbCommand("select movie_id from event", oc);
    oc.open();
        
        OleDbDataReader ol1 = cmd1.ExecuteReader();
        while (ol1.Read())
        {
            if (ol1.GetValue(0).ToString() == dateTimePicker1.Value.ToString("MM/dd/yyyy") || 
                ol1.GetValue(1).ToString() == dateTimePicker2.Value.ToString("MM/dd/yyyy"))
                goto abc;
        }
    oc.close();
        OleDbCommand cmd1 = new OleDbCommand("select [open date],[close date] from event", oc);
        oc.open();
        OleDbDataReader ol = cmd.ExecuteReader();
        ol.Read(); // consider revising that section
        if (textBox1.Text.Equals(ol.GetString(0)))
            label8.Text = "ID already exists";
        else
        {
            insert_database();
            clear();
            this.Close();
        }
        abc:  label8.Text = "Open date or Close date already assigned";
        }
