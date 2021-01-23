public static void MultiKeyPress(KeyCode[] keys){
    INPUT[] inputs = new INPUT[keys.Count() * 2];
    for(int a = 0; a < keys.Count(); ++a){
        for(int b = 0; b < 2; ++b){
            inputs[(b == 0) ? a : inputs.Count() - 1 - a].Type = 1;
            inputs[(b == 0) ? a : inputs.Count() - 1 - a].Data.Keyboard = new KEYBDINPUT() {
                Vk = (ushort)keys[a],
                Scan = 0,
                Flags = Convert.ToUInt32((b == 0)?0:2),
                Time = 0,
                ExtraInfo = IntPtr.Zero,
            };
        }
    }
    if (SendInput(Convert.ToUInt32(inputs.Count()), inputs, Marshal.SizeOf(typeof(INPUT))) == 0)
        throw new Exception();
}
//call with this :
MultiKeyPress(new virtualInputs.KeyCode[] { KeyCode.LSHIFT, KeyCode.KEY_A });
/!\ the window that have the focus will get the keypress so you need to make sure the right window have the focus
