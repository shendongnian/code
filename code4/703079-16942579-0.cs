    <?xml version="1.0" encoding="utf-8" ?>
    <configuration>
    
      <configSections>
        <section name="global" type="Project.GlobalConfigSection, Project" />
        <section name="replication" type="Project.Replication.ReplicationConfigSection, Project.Replication" />
        <section name="processing" type="Project.Processing.ProcessingConfigSection, Project.Processing" />
      </configSections>
    
      <global>
        <streamNames>
          <streamName name="STREAM_DATA_14360" id="1"/>
        </streamNames>
      </global>
    
      <replication>
        <streams>
          <stream nameId="1" />
        </streams>
      </replication>
    
      <processing dataStreamId="1" />
    
    </configuration>
