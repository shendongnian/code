      var value = dataGridView1.Rows.Cast<DataGridViewRow>().Sum(x =>
                                                                    {
                                                                      double val = 0;
                                                                      if (double.TryParse(x.Cells["Column"], out val))
                                                                        return val;
                                                                      else
                                                                        return 0;
                                                                    });
