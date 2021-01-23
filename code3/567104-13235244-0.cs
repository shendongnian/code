       foreach (System.Data.DataRow TimesRow in ALLTablesSet.Tables[DrawTbl].Rows)
        {
            recordNum = RDE.DataRowToInt(TimesRow, "RecordNum");
            AltBgCol = Tbldz.RowsBGColorAlternate(RDE.DataRowToInt(TimesRow, "RecordNum"), true);
            altBgColOnly = Tbldz.RowsBGColorAlternate(RDE.DataRowToInt(TimesRow, "RecordNum"), false);
            Response.Write(string.Format("<tr {0}>", AltBgCol));
            for (int i = 0; i < TimesRow.ItemArray.Length; i++)
            {
                if (i != (TimesRow.ItemArray.Length - 1))
                {
                    Js_NumericKprss = "onkeypress=\"return onlN(event)\""; ReadOnly = "";
                    if (RDE.CurrRowIs(TimesRow, HentalDBSchema.HTDB_Cols.TblTimeCPAReport.Comments, i))
                    {
                        Js_NumericKprss = ""; ReadOnly = "";
                    }
                    else if (RDE.CurrRowIs(TimesRow, HentalDBSchema.HTDB_Cols.TblTimeCPAReport.Fines, i)
                     || RDE.CurrRowIs(TimesRow, MyDBSchema.DBs_Cols.TblCPAReport.PhoneExpences, i)
                     || RDE.CurrRowIs(TimesRow, MyDBSchema.DBs_Cols.TblCPAReport.SalaryPerDay, i)
                     || RDE.CurrRowIs(TimesRow, MyDBSchema.DBs_Cols.TblCPAReport.SalaryPerMonth, i)
                     || RDE.CurrRowIs(TimesRow, MyDBSchema.DBs_Cols.TblCPAReport.TotalGrossWages, i)
                     || RDE.CurrRowIs(TimesRow, MyDBSchema.DBs_Cols.TblCPAReport.TravelFee, i))
                    {
                        ReadOnly = "";
                        Js_NumericKprss = "onkeypress=\"return onlN(event)\"";
                    }
                    else
                        ReadOnly = "READONLY";
                    TxtRndr = string.Format("<td><input type='text' id=\"{0}_{1}\" value=\"{2} \" style=\"width:50px;{3} border:none; \" class=\"RepTblDataTDs\" {5} {6} \\></td>{4}", TimesCol[i], TimesRow["RecordNum"], TimesRow[i], altBgColOnly, Environment.NewLine + "\t\t\t", Js_NumericKprss, ReadOnly);
                }
                else
                {
                    TxtRndr = string.Format("<td><input type='image' id=\"{0}_{1}\" src=\"images/Save.png\" style=\"width:25px;{3}\" style=\"width:25px\" onclick=\"UbpdateTblCPA(this, {1});\" /></td>{4}", "imgBut", i + 1, TimesRow[i], altBgColOnly, Environment.NewLine + "\t\t\t");
                }
                Response.Write(TxtRndr);
                count++;
            }
        }
