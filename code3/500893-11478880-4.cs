    public class CheckoutController
    {
        private readonly ICommandHandler<CheckoutCommand> _checkoutHandler;
    
        public CheckoutController(ICommandHandler<CheckoutCommand> checkoutHandler)
        {
            _checkoutHandler = checkoutHandler;
        }
        [HttpPost]
        public virtual ActionResult Post(CheckoutViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);
            var command = Mapper.Map<CheckoutCommand>(viewModel);
            _checkoutHandler.Handle(command);
            return RedirectToAction("Complete");
        }
        public virtual ActionResult Complete()
        {
            return View();
        }
    }
