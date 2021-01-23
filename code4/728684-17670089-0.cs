    List<string> rolls = new List<string>();
    rolls.Add("ROLL4");//HERE THERE CAN BE A ISSUE
    rolls.Add("ROLL6");
    rolls.Add("ROLL5");
    rolls.Add("ROLL1");
    rolls.Add("ROLL2");
    rolls.Add("ROLL3");
            StringBuilder sb = new StringBuilder();
            foreach (var roll in rolls)
                sb.Append("'" + roll + "',");
            string rollList = sb.ToString().TrimEnd(',');
            string sql =
                       @"SELECT enrolment_status, roll_number FROM dt_modular_enrolment WHERE id_student = ?
                    AND roll_number in " + "( " + rollList + " )";
