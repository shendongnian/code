    public class FightCardsController : Controller
    {
        private MyContext context = new MyContext();
        public ActionResult Details(int id)
        {
            FightCard fightCard = context.FightCards.Find(id);
            if (fightCard == null)
            {
                return this.HttpNotFound();
            }
            return this.View(fightCard);
        }
    }
