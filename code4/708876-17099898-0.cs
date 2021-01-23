            for (int i = 0; i < u.StarCount; i++)
            {
                bool badStar = true;  //Assume failure
                do
                {
                    //Create a star, get a random location, and where the rarity of its spectral type
                    StellarBody sb = new StellarBody();
                    sb.PositionX = r.Next(0, u.width);
                    sb.PositionY = r.Next(0, u.height);
                    int randomAbundance = r.Next(maxAbundance);
                    //Test the location against previous stars added, disallow positions where the centers are within 8 units of one another
                    if (!u.StellarBodies.Any(p => Math.Abs(p.PositionX.Value - sb.PositionX.Value) < minGap && Math.Abs(p.PositionY.Value - sb.PositionY.Value) < minGap))
                    {
                        //Get the spectral types based on the abundance value of the spectral types compared to the random abundance number
                        List<Models.StellarClass> abundanceTypes = starTypes.FindAll(f => f.Abundance == starTypes.Where(p => p.Abundance > randomAbundance).Min(m => m.Abundance));
                        try
                        {
                            int index = r.Next(0, abundanceTypes.Count());
                            sb.StellarClassID = abundanceTypes[index].StellarClassID;                            
                            sb.CatalogDesignation = index.ToString() + u.StellarBodies.Count.ToString()
                                                    + abundanceTypes[index].Code + "-" + CoordinateMath.GetMortonNumber((int)sb.PositionX, (int)sb.PositionY).ToString();
                            minOrbit = abundanceTypes[index].MinOrbitZone;
                            maxOrbit = abundanceTypes[index].MaxOrbitZone;
                        }
                        catch (Exception ex)
                        {
                            sb.StellarClassID = starTypes.First(p => p.Code.Equals("Dork", StringComparison.CurrentCultureIgnoreCase)).StellarClassID;
                        }
  
                        u.StellarBodies.Add(sb);
                        badStar = false;
                    }
                } while (badStar);
            }
