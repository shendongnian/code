    var xml = XElement.Parse(
                    @"<shrtcutkeys>
                            <Keysmain>
                                <keychars>
                                    <key1>
                                        Ctrl
                                    </key1>
                                    <key1>
                                        Alt
                                    </key1>
                                    <key1>
                                        Shift
                                    </key1>
                                </keychars>
                            </Keysmain>
                            <Seckeys>
                                <keychars>
                                    <key2>
                                        Ctrl
                                    </key2>
                                    <key2>
                                        Alt
                                    </key2>
                                    <key2>
                                        Shift
                                    </key2>
                                </keychars>
                            </Seckeys>
                            <Alphas>
                                <keychars>
                                    <key3>
                                        a
                                    </key3>
                                    <key3>
                                        b
                                    </key3>
                                    <key3>
                                        c
                                    </key3>
                                </keychars>
                            </Alphas>
                        </shrtcutkeys>");
    var key1 = xml.Descendants("key1");
    foreach (var key in key1)
        comboBox1.Items.Add(key.Value.Trim());
    var key2 = xml.Descendants("key2");
    foreach (var key in key2)
        comboBox2.Items.Add(key.Value.Trim());
    //Do the same for other keys...
