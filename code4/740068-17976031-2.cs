    class ManagerCar : IBlalba
    {
        public void Render(IViewTemplate template)
        {
            if (template.GetType() == typeof(CarViewTemplate))
            {
                //Do some stuff
            }
        }
    }
