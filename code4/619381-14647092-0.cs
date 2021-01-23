        /// <summary>
        /// Compares the upgrade to another upgrade
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            //Int reference table:
            //1 or greater means the current instance occurs after obj
            //0 means both elements occur in the same position
            //-1 or less means the current instance occurs before obj
            if (obj == null)
                return 1;
            Upgrade otherUpgrade = obj as Upgrade;
            if (otherUpgrade != null)
            {
                //Split strings into arrays
                string[] splitStringOne = _name.Split(new char[] { ' ' });
                string[] splitStringTwo = otherUpgrade.Name.Split(new char[] { ' ' });
                //Will hold checks to see which comparer will be used
                bool sameWords = false, sameLength = false, bothInt = false;
                //Will hold the last part of the string if it is an int
                int intOne = 0, intTwo = 0;
                //Check if they have the same length
                sameLength = (splitStringOne.Length == splitStringTwo.Length);
                if (sameLength)
                {
                    //Check to see if they both end in an int
                    bothInt = (int.TryParse(splitStringOne[splitStringOne.Length - 1], out intOne) && int.TryParse(splitStringTwo[splitStringTwo.Length - 1], out intTwo));
                    if (bothInt)
                    {
                        //Check to see if the previous parts of the string are equal
                        for (int i = 0; i < splitStringOne.Length - 2; i++)
                        {
                            sameWords = (splitStringOne[i].ToLower().Equals(splitStringTwo[i].ToLower()));
                            if (!sameWords)
                                break;
                        }
                    }
                }
                //If all criteria is met, use the customk comparer
                if (sameWords && sameLength && bothInt)
                {
                    if (intOne < intTwo)
                        return -1;
                    else if (intOne > intTwo)
                        return 1;
                    else //Both equal
                        return 0;
                }
                //Else use the default string comparer
                else
                    return _name.CompareTo(otherUpgrade.Name);            
            }
            else
                throw new ArgumentException("Passed object is not an Upgrade.");
        }
