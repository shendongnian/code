    class Duel {
        public Duel(string user1, string user2) {
            Debug.Assert(user1 != user2);
            User1 = user1;
            User2 = user2;
        }
        public readonly string User1;
        public readonly string User2;
        public int User1Score;
        public int User2Score;
    }
    class Program {
        static void Main(string[] args) {
            var dict = new Dictionary<string, Duel>();
            // Add a new duel. A single duel has two keys in the dictionary, one for each "endpoint".
            var duel = new Duel("Jon", "Rob");
            dict.Add(duel.User1, duel);
            dict.Add(duel.User2, duel);
            // Find Jon's score, without knowing in advance whether Jon is User1 or User2:
            var jons_duel = dict["Jon"];
            if (jons_duel.User1 == "Jon") {
                // Use jons_duel.User1Score.
            }
            else {
                // Use jons_duel.User2Score.
            }
            // You can just as easily find Rob's score:
            var robs_duel = dict["Rob"];
            if (robs_duel.User1 == "Rob") {
                // Use robs_duel.User1Score.
            }
            else {
                // Use robs_duel.User2Score.
            }
            // If Jon tries to engage in another duel while still duelling Rob:
            var duel2 = new Duel("Jon", "Nick");
            dict.Add(duel2.User1, duel); // Exception! Jon cannot be engaged in more than 1 duel at a time.
            dict.Add(duel2.User2, duel); // NOTE: If exception happens here instead of above, don't forget remove User1 from the dictionary.
            // Removing the duel requires removing both endpoints from the dictionary:
            dict.Remove(jons_duel.User1);
            dict.Remove(jons_duel.User2);
            // Etc...
        }
    }
