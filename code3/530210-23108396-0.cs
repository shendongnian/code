    DataGridViewLinkColumn dgvColDeletion = new DataGridViewLinkColumn();  
    
      
    dgvColDeletion.UseColumnTextForLinkValue = true;<br/>
                    dgvColDeletion.Text = "Delete";<br/>
                    dgvColDeletion.ActiveLinkColor = Color.White;<br/>
                    dgvColDeletion.LinkBehavior = LinkBehavior.SystemDefault;<br/>
                    dgvColDeletion.LinkColor = Color.Blue;<br/>
                    dgvColDeletion.TrackVisitedState = true;<br/>
                    dgvColDeletion.VisitedLinkColor = Color.YellowGreen;<br/>
                    dgvColDeletion.Name = "Delete";<br/>
                    dgvColDeletion.HeaderText = "Delete";<br/>
                    if (grid_shared.Columns.Contains("Delete") == false)<br/>
                    {<br/>
                        dgvColDeletion.Columns.Add(lnkDelete);<br/>
                        dgvColDeletion.Columns["Delete"].Width = 40;<br/>
                    }<br/>
