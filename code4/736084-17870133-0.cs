    public static string ShowMyEnumTitle(this HtmlHelper helper, myEnum enumTitle)
            {
                string enumText = "";
                string result = "";
                enumText = String.Format("{0}", Enum.GetName(typeof(myEnum), enumTitle));
                for (int i = 0; i < enumText.Length; i++)
                {
                    if ((int)enumText[i] >= 65 && (int)enumText[i] <= 90 && i != 0)
                    {
                        result += " " + enumText[i];
                    }
                    else
                    {
                        result += enumText[i];
                    }
                }
                return result;
            }
