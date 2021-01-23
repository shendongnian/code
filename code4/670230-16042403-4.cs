	 <ListView.View>
		 <GridView>
			<GridViewColumn Header="Movie Name">
				<GridViewColumn.CellTemplate>
					<DataTemplate>
						<Grid>
							<TextBlock Text="{Binding ObsMovies.MovieName}" />
						</Grid>
					</DataTemplate>
				</GridViewColumn.CellTemplate>
			</GridViewColumn>
			<GridViewColumn Header="Year" Width="60">
				<GridViewColumn.CellTemplate>
					<DataTemplate>
						<Grid>
							<TextBlock Text="{Binding ObsMovies.Year}" />
						</Grid>
					</DataTemplate>
				</GridViewColumn.CellTemplate>
			</GridViewColumn>
		</GridView>
	</ListView.View>
