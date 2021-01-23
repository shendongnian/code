    class CloseTagedForm
     {
            public void ZatvoriTagovanuFormu(string myTag)
            {
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)//when you have to change the items you should do a reverse loop !
                if (Application.OpenForms[i].Tag != null && Application.OpenForms[i].Tag.ToString() == myTag)
                    Application.OpenForms[i].Close();
            }
     }
