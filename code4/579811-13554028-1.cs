    Visits v = new Visit();
    Pickups p = new Pickup();
    lstVisits.Items.Add(v);
    lstVisits.Items.Add(p);    
    
    
    private void lstVisits_SelectedIndexChanged(object sender, EventArgs e)
                {
                    if (listBox1.SelectedItems.Count > 0)
                    {
                        object o = listBox1.SelectedItems[0];
                        if (o is Visits)
                        {
                            Visits visit = (Visits)o;
                            Visitsform.visits = visit;
                            Visitsform.ShowDialog();
                        }
                        else
                        {
                            Deliveries delivery = (Deliveries)o;
                            Deliveriesform.visits = visit;
                            Deliveriesform.ShowDialog();
                        }
                    }
                }
