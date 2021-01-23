    int stageOrdinal = dr.GetOrdinal("STAGE");
    while (dr.Read()) {
         dto = new DataTransferObject();
         if (dr.IsDBNull(stageOrdinal)) {
             dto.Stage = 1;
         } else {
             dto.Stage = dr.GetInt32(stageOrdinal);
         }
         //TODO: retrieve other columns.
         dtoList.Add(dto);
    }
