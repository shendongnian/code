    var voxel = voxelMeshEditor.GetVoxel(0, 0, 0);  // Copy REFERENCE, and NOT value
    
    SetVoxelSelected(ref voxel);   //Set selctede vortex reference
    
    Console.WriteLine(voxelSelected == null); // False, CORRECT !
    
    voxelMeshEditor.RemoveVoxel(0, 0, 0); //REMOVE
    
    Console.WriteLine(voxelSelected == null); 
    /* Selected vortex still pointing to the memroy location it was pointing before. 
       The fact is that memory location is not more in array, doesn't matter. 
       So CORRECT ! */
