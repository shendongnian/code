    public sealed partial class MainPage : Page
    {
        public static MobileServiceClient MobileService = new MobileServiceClient(
            "https://YOUR-APP-NAME-HERE.azure-mobile.net/",
            "YOUR-APP-KEY-HERE"
        );
        public MainPage()
        {
            this.InitializeComponent();
        }
        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
        private async void btnStart_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                Game game = new Game();
                game.pieceLocations = new Dictionary<Tuple<int, int>, BoardSpaceState>();
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        game.pieceLocations[Tuple.Create(i, j)] = BoardSpaceState.None;
                    }
                }
                game.pieceLocations[Tuple.Create(1, 2)] = BoardSpaceState.FriendlyPieceShort;
                game.pieceLocations[Tuple.Create(2, 1)] = BoardSpaceState.FriendlyPieceTall;
                game.pieceLocations[Tuple.Create(3, 4)] = BoardSpaceState.OpponentPieceShort;
                game.pieceLocations[Tuple.Create(4, 3)] = BoardSpaceState.OpponentPieceTall;
                var table = MobileService.GetTable<Game>();
                await table.InsertAsync(game);
                AddToDebug("Inserted game: ", game.Id);
                AddToDebug("Now trying to retrieve it...");
                var allGames = await table.ToListAsync();
                AddToDebug("All games, length = {0}", allGames.Count);
            }
            catch (Exception ex)
            {
                AddToDebug("Error: {0}", ex);
            }
        }
        void AddToDebug(string text, params object[] args)
        {
            if (args != null && args.Length > 0) text = string.Format(text, args);
            this.txtDebug.Text = this.txtDebug.Text + text + Environment.NewLine;
        }
    }
    [DataTable(Name = "Test")]
    public class Game
    {
        public int Id { get; set; }
        [DataMemberJsonConverter(ConverterType = typeof(DictionaryJsonConverter))]
        public Dictionary<Tuple<int, int>, BoardSpaceState> pieceLocations { get; set; }
    }
    public enum BoardSpaceState
    {
        FriendlyPieceShort,
        FriendlyPieceTall,
        OpponentPieceShort,
        OpponentPieceTall,
        None
    }
    public class DictionaryJsonConverter : IDataMemberJsonConverter
    {
        public static Tuple<int, int> tupleOfString(string str)
        {
            var match = Regex.Match(str, @"\((\d+), (\d+)\)");
            // need to grab indexes 1 and 2 because 0 is the entire match
            return Tuple.Create(int.Parse(match.Groups[1].Value), int.Parse(match.Groups[2].Value));
        }
        public object ConvertFromJson(IJsonValue val)
        {
            var dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(val.GetString());
            var deserialized = new Dictionary<Tuple<int, int>, BoardSpaceState>();
            foreach (var pieceLoc in dict)
            {
                deserialized[tupleOfString(pieceLoc.Key)] = (BoardSpaceState)Enum.Parse(typeof(BoardSpaceState), pieceLoc.Value);
            }
            return deserialized;
        }
        public IJsonValue ConvertToJson(object instance)
        {
            var dict = (IDictionary<Tuple<int, int>, BoardSpaceState>)instance;
            IDictionary<Tuple<int, int>, string> toSerialize = new Dictionary<Tuple<int, int>, string>();
            foreach (var pieceLoc in dict)
            {
                /** There may be an easier way to convert the enums to strings
                 * http://stackoverflow.com/questions/2441290/json-serialization-of-c-sharp-enum-as-string
                 * By default, Json.NET just converts the enum to its numeric value, which is not helpful.
                 * There could also be a way to do these dictionary conversions in a more functional way.
                 */
                toSerialize[pieceLoc.Key] = pieceLoc.Value.ToString();
            }
            var serialized = JsonConvert.SerializeObject(toSerialize);
            return JsonValue.CreateStringValue(serialized);
        }
    }
