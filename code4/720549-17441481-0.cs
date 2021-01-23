    var words = string.Split(' ', StringSplitOptions.None); // this keeps the spaces as "epmty words"
    var scrambled = words.Select(w => { if (String.IsNullOrEmpty(w))
                                              return w;
                                        else {
                                             ScrambleTextBoxText scrmbltb = new ScrambleTextBoxText(words[i]);
                                             scrmbltb.GetText();
                                             return scrmbltb.scrambledWord;
                                        }
                                      });
    var result = string.Join(" ", scrambled);
