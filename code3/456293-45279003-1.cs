    private void button_valider_Click(object sender, EventArgs e)
        {
            SqlCeConnection connexion =Connexion.getInstance().OpenConnection();
            Cars= new List<Car>();
            Cars= _cars .GetAllCars().ToList();
            foreach (var car in Cars)
            {
                int year= car.year;
                 ...
                
            }
        }
