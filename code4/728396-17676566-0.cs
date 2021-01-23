    for (int i = 0; i < rs.Count; i++)
                    {
                        r.ReservationTime = r.ReservationTime;
                        rs[i].ReservationTime = DateTime.Parse(rs[i].ReservationTime.ToString());
                        if (thisdate.CompareTo(rs[i].ReservationTime) != 0)
                        {
                            foreach (string c in courtNames)
                            {
                                lboxCourts.Items.Add(c);
                            }
                        }
                        else
                        {
                            lboxCourts.Items.Clear();
                            foreach (string c in courtNames)
                            {
                                lboxCourts.Items.Add(c);
                            }
                            for (int j = 0; j < rs.Count; j++)
                            {
                                if (r.ReservationTime.Equals(rs[j].ReservationTime))
                                {
                                    string courtName = BookingManager.getInstance().getNameById(rs[j].CourtId);
                                    lboxCourts.Items.Remove(courtName);
                                }
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                MessageBox.Show("Den valgte dato er ikke gyldig! - vær opmærksom på at hvis du vælger dags dato, at tidspunktet ikke kan være tidligere end nuværende tidspunkt!");
            }
        }
