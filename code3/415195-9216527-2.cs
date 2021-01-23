    public static void Test()
    {
        UnitCategory troopsCategory = new UnitCategory
            {
                UnitCategoryName = "Troops",
                UnitType = new List<UnitType>
                    {
                        new UnitType
                            {
                                UnitTypeName = "Infantry",
                                Unit = new List<Unit>
                                    {
                                        new Unit
                                            {
                                                Armour = "Chitin",
                                                Attacks = "3",
                                                BallisticSkill = "100",
                                                Compsition = "20",
                                                DedicatedTransport = "No",
                                                Initiative = "3",
                                                Leadership = "5",
                                                Options = "8",
                                                SaveThrow = "6+",
                                                SpecialRules = "None",
                                                Strength = "3",
                                                T = "4",
                                                UnitName = "Hornmagant",
                                                Weapons = "Many",
                                                WeaponSkill = "3",
                                                Wounds = "1"                                               
                                            }
                                    }
                            }
                    }
            };
        Army army = new Army
        {
            ArmyName = "Tyranid",
            UnitCategory = new List<UnitCategory>
                {
                    troopsCategory
                }
        };
        ArmyListing armyListing = new ArmyListing
        {
            Army = new List<Army>
                    {
                        army
                    }
        };
        armyListing.SerializeToXml(armyListing);
    }
