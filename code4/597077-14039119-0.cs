    public static class ILUtils
    {
        private static Dictionary<short, OpCode> s_opcodes = new Dictionary<short, OpCode>();
        static ILUtils()
        {
            FieldInfo[] opCodeFields = typeof(OpCodes).GetFields(BindingFlags.Public | BindingFlags.Static);
            foreach (FieldInfo opCodeField in opCodeFields)
            {
                if (opCodeField.FieldType != typeof(OpCode))
                    continue;
                OpCode opcode = (OpCode)opCodeField.GetValue(null);
                s_opcodes.Add(opcode.Value, opcode);
            }
        }
        public static bool ContainsOpcodes(MethodInfo methodInfo, IEnumerable<OpCode> targetOpCodes)
        {
            MethodBody methodBody = methodInfo.GetMethodBody();
            using (BinaryReader ilReader = new BinaryReader(new MemoryStream(methodBody.GetILAsByteArray())))
            {
                while (ilReader.BaseStream.Position < ilReader.BaseStream.Length)
                {
                    short opCodeValue = ilReader.ReadByte();
                    if (opCodeValue == 0xfe)
                        opCodeValue = (short)(opCodeValue << 8 | ilReader.ReadByte());
                    OpCode opCode = s_opcodes[opCodeValue];
                    if (targetOpCodes.Contains(opCode))
                        return true;
                    int argumentSize = 4;
                    if (opCode.OperandType == OperandType.InlineNone)
                        argumentSize = 0;
                    else if (opCode.OperandType == OperandType.ShortInlineBrTarget || opCode.OperandType == OperandType.ShortInlineI || opCode.OperandType == OperandType.ShortInlineVar)
                        argumentSize = 1;
                    else if (opCode.OperandType == OperandType.InlineVar)
                        argumentSize = 2;
                    else if (opCode.OperandType == OperandType.InlineI8 || opCode.OperandType == OperandType.InlineR)
                        argumentSize = 8;
                    else if (opCode.OperandType == OperandType.InlineSwitch)
                    {
                        int num = ilReader.ReadInt32();
                        argumentSize = (int)(4 * num + 4);
                    }
                    ilReader.BaseStream.Position += argumentSize;
                }
            }
            return false;
        }
    }
