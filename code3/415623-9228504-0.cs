	txt.Select();
	SendKeys.Send("hello");
	SendKeys.Send(((char)0x8).ToString()); // send backspace using 0x08
	SendKeys.Send("{BS}"); // send backspace using predefined code
	SendKeys.Send("world");
