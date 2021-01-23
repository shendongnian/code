    private void GenerarFichero_Click(object sender, RoutedEventArgs e)
    {
        string valEmisora = "02827003";
        string codigoCabecera;
        if (DateTime.Today.Day > 7)
            codigoCabecera = "AE570200";
        else
            codigoCabecera = "AE570100";
        using (StreamWriter sw = new StreamWriter(codigoCabecera.Remove(6, 2)))
        {
            sw.WriteLine("775701    " + DateTime.Now.ToString("yy") + DateTime.Now.Month.ToString("d2") + DateTime.Now.AddDays(1).Day.ToString("d2") + DateTime.Now.Hour.ToString("d2") + DateTime.Now.Minute.ToString("d2") + "008910                    00" + txtBanco.Text + codigoCabecera + txtBanco.Text + "");
            sw.WriteLine("0170      " + valEmisora + "    " + this.txtBanco.Text + "          10" + DateTime.Now.ToString("MM") + DateTime.Now.ToString("yy"));
    
            SelectBD sel = new SelectBD(App.ConexBD, "SELECT * FROM Seguros");
            var Query = sel.DataTable.AsEnumerable().Select(row =>
                    {
                        return new      
                        {      
                            banco = row["banco"].ToString(),
                            emisora = row["emisora"].ToString(),
                            sucursal = row["sucursal"].ToString(),
                            fecha = row["fecha"].ToString(),
                            identificacion = row["identificacion"].ToString(),
                            importe = row["importe"].ToString(),
                            importe_dec = row["importe_dec"].ToString(),
                            provincia = row["provincia"].ToString(),
                            referencia = row["referencia"].ToString(),
                        };
                    });
            var OutputQuery = Query.GroupBy(l => l.emisora);
            List<int> TotalRegistros = new List<int>();
            List<int> TotalSumas = new List<int>();
            foreach (var grupo in OutputQuery)
            {
                sw.WriteLine("0270      " + valEmisora + grupo.Key + " " + this.txtBanco.Text + "          10" + DateTime.Now.ToString("MM") + DateTime.Now.ToString("yy"));
                List<int> Suma = new List<int>();
                foreach (var data in grupo)
                {
                    Suma.Add(Convert.ToInt32(data.importe + data.importe_dec));
                    sw.WriteLine("6070      " + valEmisora + data.emisora + "1" + data.banco + data.sucursal + data.fecha + data.importe + data.importe_dec + data.identificacion + "                      " + data.referencia);
                }
                TotalRegistros.Add((grupo.Count() + 2));
                TotalSumas.Add(Suma.Sum());
                sw.WriteLine("8070      " + valEmisora + grupo.Key + " " + (grupo.Count() + 2).ToString().PadLeft(6, '0') + "        " + Suma.Sum().ToString().PadLeft(12, '0'));
            }
            sw.WriteLine("9070      " + valEmisora + "    " + (TotalRegistros.Sum() + 2).ToString().PadLeft(6, '0') + "        " + TotalSumas.Sum().ToString().PadLeft(12, '0'));
            this.txtTotal.Text = TotalSumas.Sum().ToString();
        }
        MessageBox.Show("El fichero ha sido guardado, ya no se puede editar");
    }
