    using Mono.Cecil;
    using Mono.Cecil.Cil;
    
    [...]
    
    
    public void Print( ) {
        AssemblyDefinition assembly = AssemblyDefinition.ReadAssembly( this.module_name );
	
        int i = 0, j = 0;
        foreach ( TypeDefinition t in assembly.MainModule.Types ) {
            if ( t.Name  == "FooClass" ) {
                j = i;
            }
            i++;
        }
	
        TypeDefinition type = assembly.MainModule.Types[ j ];
	
        i = j = 0;
        foreach ( MethodDefinition md in type.Methods ) {
            if ( md.Name == "BarMethod" ) {
                j = i;
            }
            i++;
        }
	
        MethodDefinition foundMethod = type.Methods[ j ];
	
        foreach( Instruction instr in foundMethod.Body.Instructions ) {
            System.Console.WriteLine( "{0} {1} {2}", instr.Offset, instr.OpCode, instr.Operand );
        }
    }
