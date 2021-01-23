    public struct ChannelVars {
          public bool FetchData; 
          public object Data;   
          public uint Lines;    
    }
    public struct HDFCallVarsT {
          public ChannelVars PVars;
          public ChannelVars SVars; 
          //enum FILE_VERSION file_vers;  //you will need to get the enum set here correctly
          public bool FetchN;
          public SLineHeaderT NAddr; //SLineHeaderT must be a class somewhere
          public uint NLines;
          public CSDTFileHeaderT HDR; //CSDTFileHeaderT must be a class somewhere   
    };
