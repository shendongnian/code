    //m_text is the whole text i want to write. It may contain special characters,
    //like 'enter', 'tab', lower/upper-case chars, and chars with shit/alt is
    //pressed, like ';'.
                    //Test with this string, its difficult-enough. :)
                    string m_text = "123qweQWE;{tab}!{eNTer}*|";
                    IntPtr keyboardLayout = GetKeyboardLayout(0);
    
                    while (!string.IsNullOrWhiteSpace(m_text))
                    {
                        int m_Index = 0;
                        //Enter, tab and similar keys are in {} brackets
                        //(for example {tab}). We get the 'tab' from the
                        //string and pass this to our method. Key combinations
                        //are separated by a '+' like {alt+tab+tab}, from this
                        //we will get 'press the alt, then press the tab, then
                        //press the tab again'.
                        if (m_text[m_Index] == '{')
                        {
                            #region [ Special chars ]
                            string m_SubString = m_text.Substring(
                                                        m_Index + 1, m_text.IndexOf("}") - 1);
                            string[] m_Splitted = m_SubString.Split(new char[] { '+' });
                            for (int i = 0; i < m_Splitted.Length; i++)
                            {
                                //If the string is longer than 1 char it means we are processing a tab-like key.
                                if (m_Splitted[i].Length > 1)
                                    PressSpecial(m_Splitted[i]);
                                else
                                {
                                    //If the char is 1-char-long, it means we previously pressed a tab-like key,
                                    //and now we press a simple key, like in the case of {altgr+w}.
                                    //Get the virtual key of the char.
                                    short vKey = VkKeyScanEx(
                                        char.Parse(m_Splitted[i]), keyboardLayout);
                                    //Get the low byte from the virtual key.
                                    byte m_LOWBYTE = (Byte)(vKey & 0xFF);
                                    //Get the scan code of the key.
                                    byte sScan = (byte)MapVirtualKey(m_LOWBYTE, 0);
                                    //Press the key.
                                    //Key down event, as indicated by the 3rd parameter that is 0.
                                    keybd_event(m_LOWBYTE, sScan, 0, 0);
                                }
                            }
                            Application.DoEvents();
                            //We have pressed all the keys we wanted, now release them in backward-order
                            //when pressing alt+tab we beed to release them in tab-alt order! The logic is the same.
                            for (int i = m_Splitted.Length - 1; i > -1; i--)
                            {
                                if (m_Splitted[i].Length > 1)
                                    ReleaseSpecial(m_Splitted[i]);
                                else
                                {
                                    short vKey = VkKeyScanEx(
                                        char.Parse(m_Splitted[i]), keyboardLayout);
                                    byte m_LOWBYTE = (Byte)(vKey & 0xFF);
                                    byte sScan = (byte)MapVirtualKey(m_LOWBYTE, 0);
                                    //Key up event, as indicated by the 3rd parameter that is 0x0002.
                                    keybd_event(m_LOWBYTE, sScan, 0x0002, 0); //Key up
                                }
                            }
                            Application.DoEvents();
                            #endregion
                            //We do not use the '{' and '}' brackets, thats why the '+2'. :)
                            m_Index = m_SubString.Length + 2;
                        }
                        else
                        {
                            #region [ One char ]
                            short vKey = VkKeyScanEx(m_text[m_Index], keyboardLayout);
                            //Hi-byte indicates if we need to press shift, alt or other similar keys.
                            byte m_HIBYTE = (Byte)(vKey >> 8);
                            byte m_LOWBYTE = (Byte)(vKey & 0xFF);
                            byte sScan = (byte)MapVirtualKey(m_LOWBYTE, 0);
                            //Press the special key if needed.
                            if ((m_HIBYTE == 1))
                                PressShift();
                            else if ((m_HIBYTE == 2))
                                PressControl();
                            else if ((m_HIBYTE == 4))
                                PressAlt();
                            else if ((m_HIBYTE == 6))
                                PressAltGr();
                            //Press, then release the key.
                            keybd_event(m_LOWBYTE, sScan, 0, 0); //Key down
                            keybd_event(m_LOWBYTE, sScan, 0x0002, 0); //Key up
                            //Release the special key if needed.
                            if ((m_HIBYTE == 1))
                                ReleaseShift();
                            else if ((m_HIBYTE == 2))
                                ReleaseControl();
                            else if ((m_HIBYTE == 4))
                                ReleaseAlt();
                            else if ((m_HIBYTE == 6))
                                ReleaseAltGr();
                            #endregion
                            //Get the next char from the string.
                            m_Index++;
                        }
                        //Remove the already processed chars from the string.
                        if (m_Index < m_text.Length)
                            m_text = m_text.Substring(m_Index);
                        else
                            m_text = string.Empty;
                    }
