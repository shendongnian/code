    public ActionResult Calculation(int id)
            {
                ViewData["Message"] = String.Format("{0} when squared produces {1}", id, Models.Mathematics.Square(id));
                return View();
            }
