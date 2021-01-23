       //Empiezo el ciclo
        while (usuarioDR.Read())
        {
            MessageBox.Show("Paso por aca 2"); // <- It does not execute
            if (usuarioDR["fechahora"].ToString() != "")
            {
                MessageBox.Show("Paso por aca 3");
                tipo = (DateTime)usuarioDR["fechahora"];
                MessageBox.Show(tipo.ToString());
            }
            else
            {
                validar = true;
                MessageBox.Show("Paso por aca 1");
            }
        }
