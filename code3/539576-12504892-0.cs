    using System;
    using System.Runtime.InteropServices;
    
    public class ActiveProjects
    {
        public string[] ProjectPaths { get; set; }
        public ushort[] InstanceIds { get; set; }
        public string[] MachineNames { get; set; }
        public string[] ControllerIps { get; set; }
        public string[] ModelPaths { get; set; }
        public ushort[] NumberOfModelsPerProject { get; set; }
        public ushort[] ModelIds { get; set; }
        public ushort[] ModelStates { get; set; }
    
        [DllImport("<the DLL>")]
        unsafe private static int OpalGetActiveProjects(
            ushort allocatedProjects,
            ushort* numProjects,
            ushort allocatedModels,
            ushort* numModels,
            ushort allocatedProjectsPathLen,
            ushort* maxProjectPathLen,
            ushort allocatedModelPathLen,
            ushort* maxModelPathLen,
            ushort allocatedMachineNameLen,
            ushort* maxMachineNameLen,
            ushort allocatedIpLen,
            ushort* maxIpLen,
            sbyte** projectPaths,
            ushort* instanceIDs,
            sbyte** machineNames,
            sbyte** controllerIPs,
            sbyte** modelPaths,
            ushort* numModelsPerProject,
            ushort* modelIDs,
            ushort* modelStates
            );
    
        public void GetActiveProjects()
        {
            unsafe
            {
                ushort numberOfProjects = 0;
                ushort numberOfModels = 0;
                ushort maxProjectPathLength = 0;
                ushort maxModelPathLength = 0;
                ushort maxMachineNameLength = 0;
                ushort maxIpLength = 0;
    
                int result = OpalGetActiveProjects(
                    0,
                    &numberOfProjects,
                    0,
                    &numberOfModels,
                    0,
                    &maxProjectPathLength,
                    0,
                    &maxModelPathLength,
                    0,
                    &maxMachineNameLength,
                    0,
                    &maxIpLength,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null
                    );
    
                if (result != 0 && result != 123)
                    throw new Exception("Error getting active projects");
    
                sbyte** projectPaths = null;
                ushort* instanceIds = null;
                sbyte** machineNames = null;
                sbyte** controllerIps = null;
                sbyte** modelPaths = null;
                ushort* numberOfModelsPerProject = null;
                ushort* modelIds = null;
                ushort* modelStates = null;
    
                try
                {
                    projectPaths = (sbyte**)Marshal.AllocHGlobal(numberOfProjects * IntPtr.Size).ToPointer();
                    for (int i = 0; i < numberOfProjects; ++i)
                        projectPaths[i] = null;
                    for (int i = 0; i < numberOfProjects; ++i)
                        projectPaths[i] = (sbyte*)Marshal.AllocHGlobal(maxProjectPathLength);
    
                    instanceIds = (ushort*)Marshal.AllocHGlobal(numberOfProjects * 2).ToPointer();
    
                    machineNames = (sbyte**)Marshal.AllocHGlobal(numberOfProjects * IntPtr.Size).ToPointer();
                    for (int i = 0; i < numberOfProjects; ++i)
                        machineNames[i] = null;
                    for (int i = 0; i < numberOfProjects; ++i)
                        machineNames[i] = (sbyte*)Marshal.AllocHGlobal(maxMachineNameLength).ToPointer();
    
                    controllerIps = (sbyte**)Marshal.AllocHGlobal(numberOfProjects * IntPtr.Size).ToPointer();
                    for (int i = 0; i < numberOfProjects; ++i)
                        controllerIps[i] = null;
                    for (int i = 0; i < numberOfProjects; ++i)
                        controllerIps[i] = (sbyte*)Marshal.AlloHGlobal(maxIpLength).ToPointer();
    
                    modelPaths = (sbyte**)Marshal.AlloHGlobal(numberOfModels * IntPtr.Size).ToPointer();
                    for (int i = 0; i < numberOfProjects; ++i)
                        modelPaths = null;
                    for (int i = 0; i < numberOfProjects; ++i)
                        modelPaths = (sbyte*)Marshal.AllocHGlobal(maxModelPathLength).ToPointer();
    
                    numberOfModelsPerProject = (ushort*)Marshal.AlloHGlobal(numberOfProjects * 2).ToPointer();
                    modelIds = (ushort*)Marshal.AllocHGlobal(numberOfModels * 2).ToPointer();
                    modelStates = (ushort*)Marshal.AllocHGlobal(numberOfModels * 2).ToPointer();
    
                    ushort numberOfProjects2 = 0;
                    ushort numberOfModels2 = 0;
                    ushort maxProjectPathLength2 = 0;
                    ushort maxModelPathLength2 = 0;
                    ushort maxMachineNameLength2 = 0;
                    ushort maxIpLength2 = 0;
    
                    OpalGetActiveProjects(
                        numberOfProjects,
                        &numberOfProjects2,
                        numberOfModels,
                        &numberOfModels2,
                        maxProjectPathLength,
                        &maxProjectPathLength2,
                        maxModelPathLength,
                        &maxModelPathLength2,
                        maxMachineNameLength,
                        &maxMachineNameLength2,
                        maxIpLength,
                        &maxIpLength2,
                        projectPaths,
                        instanceIds,
                        machineNames,
                        controllerIps,
                        modelPaths,
                        numberOfModelsPerProject,
                        modelIds,
                        modelStates
                        );
    
                    ProjectPaths = new string[numberOfProjects2];
                    for (int i = 0; i < numberOfProjects2; ++i)
                        ProjectPaths[i] = new string(projectPaths[i]);
    
                    InstanceIds = new ushort[numberOfProjects2];
                    for (int i = 0; i < numberOfProjects2; ++i)
                        InstanceIds[i] = instanceIds[i];
    
                    MachineNames = new string[numberOfProjects2];
                    for (int i = 0; i < numberOfProjects2; ++i)
                        MachineNames[i] = new string(machineNames[i]);
    
                    ControllerIps = new string[numberOfProjects2];
                    for (int i = 0; i < numberOfProjects2; ++i)
                        ControllerIps[i] = new string(controllerIps[i]);
    
                    ModelPaths = new string[numberOfModels2];
                    for (int i = 0; i < numberOfModels2; ++i)
                        ModelPaths[i] = new string(modelPaths[i]);
    
                    NumberOfModelsPerProject = new ushort[numberOfProjects2];
                    for (int i = 0; i < numberOfProjects2; ++i)
                        NumberOfModelsPerProject[i] = numberOfModelsPerProject[i];
    
                    ModelIds = new ushort[numberOfModels2];
                    for (int i = 0; i < numberOfModels2; ++i)
                        ModelIds[i] = modelIds[i];
    
                    ModelStates = new ushort[numberOfModels2];
                    for (int i = 0; i < numberOfModels2; ++i)
                        ModelStates[i] = modelStates[i];
                }
                finally
                {
                    if (projectPaths != null)
                    {
                        for (int i = 0; i < numberOfProjects && projectPaths[i] != null; ++i)
                            Marshal.FreeHGlobal(IntPtr((void*)projectPaths[i]));
    
                        Marshal.FreeHGlobal(IntPtr((void*)projectPaths));
                    }
    
                    if (instanceIds != null)
                        Marshal.FreeHGlobal(IntPtr((void*)instanceIds));
    
                    if (machineNames != null)
                    {
                        for (int i = 0; i < numberOfProjects && machineNames[i] != null; ++i)
                            Marshal.FreeHGlobal(IntPtr((void*)machineNames[i]));
    
                        Marshal.FreeHGlobal(IntPtr((void*)machineIds));
                    }
    
                    if (controllerIps != null)
                    {
                        for (int i = 0; i < numberOfProjects && controllerIps[i] != null; ++i)
                            Marshal.FreeHGlobal(IntPtr((void*)controllerIps[i]));
    
                        Marshal.FreeHGlobal(IntPtr((void*)controllerIps));
                    }
    
                    if (modelPaths != null)
                    {
                        for (int i = 0; i < numberOfModels && modelPaths[i] != null; ++i)
                            Marshal.FreeHGlobal(IntPtr((void*)modelPaths[i]));
    
                        Marshal.FreeHGlobal(IntPtr((void*)modelPaths));
                    }
    
                    if (numberOfModelsPerProject != null)
                        Marshal.FreeHGlobal(IntPtr((void*)numberOfModelsPerProject));
    
                    if (modelIds != null)
                        Marshal.FreeHGlobal(IntPtr((void*)modelIds));
    
                    if (modelStates != null)
                        Marshal.FreeHGlobal(IntPtr((void*)modelStates));
                }
            }
        }
    }
