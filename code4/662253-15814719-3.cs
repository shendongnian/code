    public static void DumpMethod(Delegate method)
    {
        var mb = method.Method.GetMethodBody();
        var il = mb.GetILAsByteArray();
        var opCodes = typeof(System.Reflection.Emit.OpCodes)
            .GetFields()
            .Select(fi => (System.Reflection.Emit.OpCode)fi.GetValue(null));
        var mappedIL = il.Select(op => opCodes.FirstOrDefault(opCode => opCode.Value == op));
        var ilWalker = mappedIL.GetEnumerator();
        while(ilWalker.MoveNext())
        {
            var mappedOp = ilWalker.Current;
            if(mappedOp.OperandType != System.Reflection.Emit.OperandType.InlineNone)
            {
                var byteCount = 0;
                long operand = 0;
                switch(mappedOp.OperandType)
                {
                    case System.Reflection.Emit.OperandType.InlineI:
                    case System.Reflection.Emit.OperandType.InlineBrTarget:
                    case System.Reflection.Emit.OperandType.InlineMethod:                
                    case System.Reflection.Emit.OperandType.InlineField:
                    case System.Reflection.Emit.OperandType.InlineSig:
                    case System.Reflection.Emit.OperandType.InlineString:
                    case System.Reflection.Emit.OperandType.InlineType:
                    case System.Reflection.Emit.OperandType.InlineSwitch:
                        byteCount = 4;
                        break;
                    case System.Reflection.Emit.OperandType.InlineI8:
                    case System.Reflection.Emit.OperandType.InlineR:
                        byteCount = 8;
                        break;
                }
                for(int i=0; i < byteCount; i++)
                {
                    ilWalker.MoveNext();
                    operand |= ((long)ilWalker.Current.Value) << (8 * i);
                }
                Console.WriteLine("{0} {1}", mappedOp.Name, operand);                    
            }
            else
            {
                Console.WriteLine("{0}", mappedOp.Name);
            }
        }
    }
