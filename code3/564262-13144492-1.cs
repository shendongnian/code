        /// <summary>
        /// Configures the aut do mapper.
        /// </summary>
        public static void ConfigureAutoMapper()
        {
            AutoMapper.Mapper.Initialize(c=> c.CreateMap<CreateMomentoCommand, Momento>().ConvertUsing(new CreateMomentoCommandToMomentoConverter()));
        }
