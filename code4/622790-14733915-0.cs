            SqlDataReader sr;
            string ticketInfo = String.Empty;
            string url = String.Empty;
            bool hasData = false;
            using (SqlConnection sc = new SqlConnection(_connString))
            {
                using (SqlCommand scmd = new SqlCommand("select_poll"))
                {
                    scmd.Connection = sc;
                    scmd.CommandType = CommandType.StoredProcedure;
                    scmd.Parameters.Add("LoginID", SqlDbType.BigInt).Value = _userLoginID;
                    scmd.Parameters.Add("FacilityID", SqlDbType.BigInt).Value = _userFacilityID;
                    sc.Open();
                    sr = scmd.ExecuteReader(CommandBehavior.CloseConnection);
                    if (sr != null)
                    {
                        while (sr.Read())
                        {
                            hasData = true;
                            ticketInfo += sr["TicketID"].ToString() + " - " + sr["Ticket"].ToString() + Environment.NewLine;
                            _url = "http://mysite/mypage.aspx?ID=" + sr["TicketID"].ToString();
                        }
                    }
                }
            }
            if (hasData)
            {
                popupNotifier1.TitleColor = System.Drawing.Color.Green;
                popupNotifier1.ContentText = ticketInfo;
                popupNotifier1.Scroll = true;
                popupNotifier1.TitlePadding = new System.Windows.Forms.Padding(2);
                popupNotifier1.ContentPadding = new System.Windows.Forms.Padding(2);
                popupNotifier1.Image = Properties.Resources.medical;
                popupNotifier1.ImagePadding = new System.Windows.Forms.Padding(10);
                popupNotifier1.Popup();
            }
        }
        public void PopUpClicked(object sender, EventArgs e)
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo(_url);
            proc.StartInfo = startInfo;
            proc.Start();
        }
