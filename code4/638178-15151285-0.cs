        public static void ChoiseAndAdd(Cab cab,ref List<Cab> listA,ref List<Cab> listC)
        {
            if (listA.Any(e => e.Car_number == cab.Car_number) || listA.Any(e => e.status == cab.status))
            {
                listC.Add(cab);
                return;
            }
            listA.Add(user);
        }
