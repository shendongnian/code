    static class NewMappingsEventResemblances
	{
		public static Likeness<T, NewMappingsEvent> WithoutProgrammaticIdentifier<T>( this Likeness<T, NewMappingsEvent> that )
		{
			return that.Without( x => x.ProgrammaticIdentifier );
		}
	}
