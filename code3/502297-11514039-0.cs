    public static void SaveTrader(trader trader)
        {
            Mentor11Entities.Refresh(System.Data.Objects.RefreshMode.StoreWins, Mentor11Entities.traders);
            GetMentor11().AddTotraders(trader);
            GetMentor11().SaveChanges();
            GetMentor11().AcceptAllChanges();
            Mentor11Entities.Refresh(System.Data.Objects.RefreshMode.StoreWins, Mentor11Entities.traders);
        }
