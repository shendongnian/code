    // Assuming dtPersonsCars is the DataTable containing two primary keys, persons and cars
           lstBoxCars.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
           for (int i = 0; i < lstBoxCars.Items.Count; i++)
           {
              if (dtPersonsCars.Rows.Find(new object[]{"PERSON", lstBoxAenderungen.Items[i].ToString()}) != null)
                  lstBoxCars.SetSelected(i, true);
           }
