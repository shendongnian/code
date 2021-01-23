        public ActionResult Index() {
            return View();
        }
        public ActionResult Edit(string id) {
            return View((string.IsNullOrEmpty(id)) ? new Test { a = "new" } : FakeRepository.Data(id));
        }
        [HttpPost]
        public ActionResult Edit(Test model) {
            if (ModelState.IsValid) {
                if (model.a == "new") {
                    //Create a new record
                } else {
                    //Update Record
                }
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public static class FakeRepository {
            public static Test Data(string a) {
                return new Test {
                    a = a,
                    b = "B",
                    c = "C"
                };
            }
        }
