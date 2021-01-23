    CompilerParameters cp = new CompilerParameters();
    // Generate debug information.
    cp.IncludeDebugInformation = true;
    // Save the assembly as a physical file.
    cp.GenerateInMemory = false;
    // Set a temporary files collection. 
    // The TempFileCollection stores the temporary files 
    // generated during a build in the current directory, 
    // and does not delete them after compilation.
    cp.TempFiles = new TempFileCollection(".", true);
