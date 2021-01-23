                        foreach (var unit in unitList)
                        {
                            //Sort units by each army
                            string unitName = unit.UnitName;
                            armyUnits.Add(unitName, unit);
                            //Sort unit properties by unit
                            List<string> properites = new List<string>();
                            properites.AddRange(new string[15]{
                            
                            unit.Composition,
                            unit.WeaponSkill,
                            unit.BallisticSkill,
                            unit.Strength,
                            unit.Initiative,
                            unit.Toughness,
                            unit.Wounds,
                            unit.Attacks,
                            unit.Leadership,
                            unit.SaveThrow,
                            unit.SpecialRules,
                            unit.DedicatedTransport,
                            unit.Options,
                            unit.Armour,
                            unit.Weapons
                            });
                        }
